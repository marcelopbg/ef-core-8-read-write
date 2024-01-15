import { useEffect, useState } from 'react';
import { postData } from './utils/utils'
import './App.css';

interface DateWrapper {
    date: string
    id: number
}

function App() {
    const [date, setDate] = useState<Date | null>(null)


    useEffect(() => {
        fetchLastDate();
    }, []);

    const fetchLastDate = async () => {
        const response = await fetch('Date');
        const result = await response.json() as DateWrapper;
        setDate(new Date(result.date));
    }

    const postDate = async () => {
        await postData("Date", '');
        await fetchLastDate();
    }

    return (
        <div>
            <h1 id="tabelLabel"> Dates </h1>
            <button onClick={() => postDate()}> Click me </button>
            {date && (
                <p> {date.toLocaleString('en-US')} </p>
            )}
        </div>
    );
}

export default App;