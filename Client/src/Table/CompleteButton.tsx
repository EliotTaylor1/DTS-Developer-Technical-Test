import { useCallback } from 'react';
import type {ButtonProps} from "./ButtonProps.ts";

export default ({ task, refreshData }: ButtonProps) => {
    const handleComplete = useCallback(() => {
        const updatedTask = {
            ...task,
            status: "Completed"
        };

        fetch(`http://localhost:5253/api/Task/${task.id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(updatedTask),
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to complete task");
                return response.json();
            })
            .then(() => refreshData())
            .catch(error => console.error("Error:", error));
    }, [task, refreshData]);

    return <button onClick={handleComplete}>Complete</button>;
};