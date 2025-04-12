import CompleteButton from "./CompleteButton";
import DeleteButton from "./DeleteButton";
//import EditButton from "./EditButton";
import type { CustomCellRendererProps } from 'ag-grid-react';

interface ActionListProps extends CustomCellRendererProps {
    refreshData: () => void;
}

export default (params: ActionListProps) => {
    return (
        <>
            <CompleteButton
                task={params.data}
                refreshData={params.refreshData}
            />
            {/*<EditButton */}
            {/*    task={params.data}*/}
            {/*    refreshData={params.refreshData}*/}
            {/*/>*/}
            <DeleteButton 
                task={params.data}
                refreshData={params.refreshData}
            />
        </>
    );
};