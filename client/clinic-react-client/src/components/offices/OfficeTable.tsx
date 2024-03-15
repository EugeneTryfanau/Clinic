import { useEffect, useState } from 'react';
import { Button, CircularProgress, Input, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useGlobalStore } from '../../store/globalStore';
import OfficeTableRow from './OfficeTableRow';
import { IOffice } from '../../models/IOffice';

const OfficeTable = () => {

    const {
        offices,
        isLoading,
        errors,
        fetchOffices,
        getOfficeById,
        createOffice,
        updateOffice,
        deleteOffice
    } = useGlobalStore((state) => ({
        offices: state.offices,
        isLoading: state.isLoading,
        errors: state.errors,
        fetchOffices: state.fetchOffices,
        getOfficeById: state.getOfficeById,
        createOffice: state.createOffice,
        updateOffice: state.updateOffice,
        deleteOffice: state.deleteOffice
    }));

    const [address, setAddress] = useState('');
    const [phone, setPhone] = useState('');
    const [active, setActive] = useState('0');

    useEffect(() => {
        const fetch = async () => {
            await fetchOffices();
        }
        fetch()
    }, [fetchOffices])

    const addOffice = (e: React.FormEvent<HTMLButtonElement>) => {
        e.preventDefault();
        let office = {
            address: address,
            registryPhoneNumber: phone,
            isActive: Number(active)
        } as IOffice;
        console.log(office);
        //createOffice(office);
    }

    return (
        <div>
            <form>
                <Input type="text" value={address} onChange={e => setAddress(e.target.value)} sx={{ width: '100%' }} placeholder='Address' />
                <Input type="text" value={phone} onChange={e => setPhone(e.target.value)}  sx={{ width: '100%' }} placeholder='Registry phone number' />
                <Input type="number" value={active} onChange={e => setActive(e.target.value)}  sx={{ width: '100%' }} placeholder='Is active' />
                <Button sx={{ width: '100%' }} onClick={(e) => addOffice(e)}>Создать офис</Button>
            </form>
            <TableContainer component={Paper} >
                <Typography
                    sx={{ flex: '1 1 100%' }}
                    padding="10px"
                    variant="h6"
                    component="div"
                    textAlign='center'
                >
                    Offices
                </Typography>

                {isLoading && <CircularProgress />}
                {errors && <h1>{errors}</h1>}

                <hr />
                <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
                    <TableHead sx={{ backgroundColor: '#81d4fa' }}>
                        <TableRow>
                            <TableCell>Address</TableCell>
                            <TableCell align="right">RegistryPhoneNumber</TableCell>
                            <TableCell align="right">IsActive</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {offices.map((row) => (
                            <OfficeTableRow key={row.id} entity={row} />
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>

    );
};

export default OfficeTable;