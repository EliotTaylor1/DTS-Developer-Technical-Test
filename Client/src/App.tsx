import { useState } from 'react';
import type { GridApi } from 'ag-grid-community';

import { Table } from './Table/Table.tsx' ;
import { Form } from './Form/Form.tsx';

import './App.css'

function App() {
    const [gridApi, setGridApi] = useState<GridApi | null>(null);


    return (
    <div className="container">
        <Form gridApi={gridApi} />
        <Table onGridReady={api => setGridApi(api)} />
    </div>
  )
}

export default App
