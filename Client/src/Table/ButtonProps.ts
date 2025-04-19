import type {Data} from "./Table.tsx";
import type { GridApi } from 'ag-grid-community';

export interface ButtonProps {
    data: Data;
    api: GridApi;
}