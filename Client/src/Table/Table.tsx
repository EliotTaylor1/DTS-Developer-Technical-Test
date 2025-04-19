import {useState, useEffect, useCallback} from "react";

import ActionList from "./ActionList.tsx";
import './table.css';

import {AgGridReact} from 'ag-grid-react';
import type {ColDef, ValueFormatterParams} from 'ag-grid-community';
import {AllCommunityModule, ModuleRegistry, CellValueChangedEvent, GridApi} from 'ag-grid-community';

ModuleRegistry.registerModules([AllCommunityModule]);

export type Data = {
    id: number;
    title: string;
    description: string;
    status: string;
    dueDate: string;
}

function dateFormatter(params: ValueFormatterParams) {
    let date = new Date(params.value);
    return date.toLocaleDateString("en-GB", {timeZone: "UTC"});
}

export function Table({onGridReady}: { onGridReady: (api: GridApi<Data>) => void }) {
    const [, setGridApi] = useState<GridApi<Data> | null>(null);
    const [rowData, setRowData] = useState<Data[]>([]);

    const getRowId = useCallback((params: { data: Data }) => params.data.id.toString(), []);

    const fetchData = useCallback(() => {
        fetch('/api/Task')
            .then(result => result.json())
            .then(data => {
                setRowData(data);
            });
    }, []);

    useEffect(() => {
        fetchData();
    }, [fetchData]);


    const onCellChange = useCallback((event: CellValueChangedEvent) => {
        const updatedData = {...event.data};

        // Handle Date as a string
        if (updatedData.dueDate) {
            const localDate = new Date(updatedData.dueDate);

            // Ensure dueDate is set to midnight UTC to avoid timezone offset issue
            const utcDate = new Date(Date.UTC(
                localDate.getFullYear(),
                localDate.getMonth(),
                localDate.getDate()
            ));
            updatedData.dueDate = utcDate.toISOString();
        }

        console.log("Updated data:", updatedData);

        fetch(`/api/Task/${updatedData.id}`, {
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(updatedData)
        })
            .then(response => {
                if (!response.ok) throw new Error('Update failed');
                return response.json();
            })
            .then(() => {
                event.api.applyTransaction({update: [updatedData]});
            })
            .catch(error => console.error('Error updating task:', error));
    }, []);
    

    const [colDefs] = useState<ColDef[]>([
        {
            field: "title",
            filter: true,
            editable: true,
            cellEditor: 'agTextCellEditor',
            cellEditorParams: {
                maxLength: 50
            },
            flex: 1,
            minWidth: 150
        },
        {
            field: "description",
            filter: true,
            editable: true,
            cellEditor: 'agLargeTextCellEditor',
            cellEditorPopup: true,
            cellEditorParams: {
                rows: 5,
                cols: 70,
                maxLength: 255
            },
            flex: 2,
            minWidth: 300
        },
        {
            field: "status",
            filter: true,
            editable: true,
            cellEditor: 'agSelectCellEditor',
            cellEditorParams: {
                values: ['Pending', 'InProgress', 'Completed'],
            },
            maxWidth: 130,
        },
        {
            field: "dueDate",
            filter: 'agDateColumnFilter',
            editable: true,
            cellEditor: 'agDateCellEditor',
            cellDataType: 'date',
            valueFormatter: dateFormatter,
            maxWidth: 130,
        },
        {
            field: "actions",
            cellRenderer: ActionList,
            maxWidth: 100,
        }
    ]);

    return (
        <div className="table">
            <AgGridReact
                onGridReady={params => {
                    setGridApi(params.api);
                    onGridReady(params.api);
                }}
                getRowId={getRowId}
                rowData={rowData}
                columnDefs={colDefs}
                pagination={true}
                onCellValueChanged={onCellChange}
            />
        </div>
    )
}