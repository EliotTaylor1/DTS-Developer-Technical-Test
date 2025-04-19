import {useState} from "react";

import './Form.css';

export function Form({ gridApi }: { gridApi: import('ag-grid-community').GridApi }) {
    const today = new Date().toISOString().split('T')[0];
    
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [date, setDate] = useState(today);
    
    const handleSubmit = event => {
        event.preventDefault();
        const data = {
            title: title,
            description: description,
            dueDate: new Date(date).toISOString(),
        }
        fetch('http://localhost:5253/api/Task', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => {
                if (!response.ok) throw new Error('Create task failed');
                return response.json();
            })
            .then(newTask => {
                if (gridApi) { // Check table exists before we try and add new task
                    gridApi.applyTransaction({ add: [newTask] });
                }
                setTitle('');
                setDescription('');
                setDate(today);
            })
            .catch(error => console.error('Error creating task:', error));
        
    }
    return (
        <form className="form" onSubmit={handleSubmit}>
            <input 
                className="title-input"
                type="text" 
                name="title"
                placeholder="Title"
                required={true}
                value={title}
                onChange={(event) => setTitle(event.target.value)}
                />
            <textarea
                className="description-input"
                name="description"
                placeholder="Description"
                value={description}
                onChange={(event) => setDescription(event.target.value)}
            />
            <input 
                className="date-input"
                type="date" 
                name="dueDate"
                value={date}
                required={true}
                onChange={(event) => setDate(event.target.value)}
            />
            <button type="submit">Create Task</button>
        </form>
    )
}