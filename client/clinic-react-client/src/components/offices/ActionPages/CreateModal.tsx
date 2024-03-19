import { Box, Button, FormControl, Input, InputLabel, MenuItem, Modal, Select } from '@mui/material';
import { useState } from 'react';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 600,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

const formStyle = {
    padding: '25px',
    background: 'white',
    borderRadius: '15px'
}

const CreateWindow: React.FC<CreateParams> = (props) => {

    const [state, setState] = useState({
        address: '',
        phone: '',
        active: 1
    });

    const createWithClosing = (e: React.FormEvent<HTMLButtonElement>) => {
        props.create(state.address, state.phone, state.active, e);
        setState(prevState => ({
            ...prevState,
            address: '',
            phone: '',
            active: 1
        }));
        props.onClose();
    }

    return (
        <Modal
            open={props.open}
            onClose={props.onClose}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
        >
            <Box sx={style}>
                <form style={formStyle}>
                    <h1>New office</h1>
                    <Input
                        type="text"
                        value={state.address}
                        onChange={e => setState(prevState => ({
                            ...prevState,
                            address: e.target.value
                        }))}
                        sx={{ width: '100%', margin: '10px' }}
                        placeholder='Address'
                    />
                    <Input
                        type="number"
                        value={state.phone}
                        onChange={e => setState(prevState => ({
                            ...prevState,
                            phone: e.target.value
                        }))}
                        sx={{ width: '100%', margin: '10px' }}
                        placeholder='Registry phone number'
                    />
                    <FormControl>
                        <InputLabel>Is active</InputLabel>
                        <Select
                            value={state.active}
                            label="Is active"
                            onChange={e => setState(prevState => ({
                                ...prevState,
                                active: e.target.value as number
                            }))}
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
            </Box>
        </Modal>
    );
};

export default CreateWindow;