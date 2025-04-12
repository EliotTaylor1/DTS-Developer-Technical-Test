import {useState, useEffect, useCallback} from "react";

import { AgGridReact } from 'ag-grid-react';
import type { ColDef, ValueFormatterParams } from 'ag-grid-community';
import { AllCommunityModule, ModuleRegistry } from 'ag-grid-community';
import ActionList from "./ActionList.tsx";
ModuleRegistry.registerModules([AllCommunityModule]);

export type Data = {
    id: number;
    title: string;
    description: string;
    status: string;
    dueDate: string;
}

function dateFormatter(params: ValueFormatterParams){
    let date = new Date(params.value);
    return date.toLocaleDateString("en-GB", { timeZone: "UTC" });
}

export function Table(){
    const [rowData, setRowData] = useState<Data[]>([]);

    const fetchData = useCallback(() => {
        fetch('http://localhost:5253/api/Task')
            .then(result => result.json())
            .then(data => setRowData(data));
    }, []);

    useEffect(() => {
        fetchData();
    }, [fetchData]);
    
    const [colDefs] = useState<ColDef[]>([
        { field: "title", filter: true },
        { field: "description", filter: true },
        { field: "status" },
        {
            field: "dueDate",
            filter: 'agDateColumnFilter',
            valueFormatter: dateFormatter
        },
        { 
            field: "actions",
            cellRenderer: ActionList,
            cellRendererParams: {
                refreshData: fetchData
            }
        }
    ]);
    
    return (
        <div style={{ height: 500 }}>
            <AgGridReact
                rowData={rowData}
                columnDefs={colDefs}
                pagination={true}
            />
        </div>
    )
}