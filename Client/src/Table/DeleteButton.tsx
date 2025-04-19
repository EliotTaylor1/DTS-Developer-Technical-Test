import type { ButtonProps } from './ButtonProps';
import './DeleteButton.css'

export default function DeleteButton({ data, api }: ButtonProps) {
    const handleDelete = () => {
        fetch(`http://localhost:5253/api/Task/${data.id}`,
            { 
                method: 'DELETE' 
            })
            .then(res => {
                if (!res.ok) throw new Error('Delete failed');
                api.applyTransaction({ remove: [data] });
            })
            .catch(err => console.error(err));
    };

    return <button className="delete-button" onClick={handleDelete}>Delete</button>;
};