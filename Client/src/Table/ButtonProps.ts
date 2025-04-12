import type {Data} from "./Table.tsx";

export interface ButtonProps {
    task: Data;
    refreshData: () => void;
}