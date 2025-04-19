import DeleteButton from "./DeleteButton";
import type { CustomCellRendererProps } from 'ag-grid-react';

export default (params: CustomCellRendererProps) => {
    return (
        <>
            <DeleteButton 
                data={params.data}
                api={params.api}
            />
        </>
    );
};