import { Button, FormControl, Input, InputLabel, MenuItem, Select } from '@mui/material';
import cl from './CreateWindow.module.css'
import { useState } from 'react';

const CreateWindow: React.FC<CreateParams> = (props) => {

    const [address, setAddress] = useState('');
    const [phone, setPhone] = useState('');
    const [active, setActive] = useState('1');

    const rootClass = [cl.createDiv];
    if (props.visible) {
        rootClass.push(cl.active);
    }

    const createWithClosing = (e: React.FormEvent<HTMLButtonElement>) => {
        props.create(address, phone, active, e);
        setAddress('');
        setPhone('');
        setActive('1');
        props.setVisibility(false);
    }

    return (
        <div className={rootClass.join(' ')} onClick={() => props.setVisibility(false)}>
            <form className={cl.createForm} onClick={(e) => e.stopPropagation()}>
                <h1>New office</h1>
                <Input type="text" value={address} onChange={e => setAddress(e.target.value)} sx={{ width: '100%', margin: '10px' }} placeholder='Address' />
                <Input type="number" value={phone} onChange={e => setPhone(e.target.value)} sx={{ width: '100%', margin: '10px' }} placeholder='Registry phone number' />
                <FormControl>
                    <InputLabel>Is active</InputLabel>
                    <Select
                        value={active}
                        label="Is active"
                        onChange={e => setActive(e.target.value)}
                    >
                        <MenuItem value={0} disabled>None</MenuItem>
                        <MenuItem value={1}>Active</MenuItem>
                        <MenuItem value={2}>Inactive</MenuItem>
                    </Select>
                </FormControl>
                <Button
                    sx={{ width: '100%' }}
                    onClick={(e) => createWithClosing(e)}
                >
                    Создать офис
                </Button>
            </form>
        </div>

    );
};

export default CreateWindow;