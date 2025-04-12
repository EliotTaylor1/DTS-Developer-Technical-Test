import { useCallback } from 'react';
import type {ButtonProps} from "./ButtonProps.ts";

export default ({ task, refreshData }: ButtonProps) => {
    const handleDelete = useCallback(() => {

        fetch(`http://localhost:5253/api/Task/${task.id}`, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
            },
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to delete task");
                return response.json();
            })
            .then(() => refreshData())
            .catch(error => console.error("Error:", error));
    }, [task, refreshData]);

    return <button onClick={handleDelete}>Delete</button>;
};