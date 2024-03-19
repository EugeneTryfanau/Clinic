import { useEffect, useState } from 'react';
import { Button, CircularProgress, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useGlobalStore } from '../../store/globalStore';
import OfficeTableRow from './OfficeTableRow';
import { IOffice } from '../../models/IOffice';
import { useNavigate } from 'react-router-dom';
import CreateModal from './ActionPages/CreateModal';

const OfficeTable = () => {

    const {
        offices,
        isLoading,
        errors,
        fetchOffices,
        createOffice,
        deleteOffice
    } = useGlobalStore((state) => ({
        offices: state.offices,
        isLoading: state.isLoading,
        errors: state.errors,
        fetchOffices: state.fetchOffices,
        createOffice: state.createOffice,
        deleteOffice: state.deleteOffice
    }));

    const navigator = useNavigate();

    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    useEffect(() => {
        const fetch = async () => {
            await fetchOffices();
        }
        fetch()
    }, [fetchOffices])

    const addOffice = (
        address: string,
        phone: string,
        active: string,
        e: React.FormEvent<HTMLButtonElement>) => {
        e.preventDefault();
        let office = {
            address: address,
            registryPhoneNumber: phone,
            isActive: Number(active)
        } as IOffice;
        createOffice(office);
    }

    const deleteOfficeById = (id: string) => {
        deleteOffice(id)
    }

    const openOfficeDetails = (id: string) => {
        navigator(`/offices/${id}`);
    }

    return (
        <div>
            <Button onClick={handleOpen}>Create office</Button>
            <CreateModal
                open={open}
                onClose={handleClose}
                create={addOffice}
            />
            <Button onClick={handleOpen}>Open modal</Button>
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
                {offices.length == 0 && isLoading == false && <h1 style={{ margin: "auto" }}>Offices were not found!</h1>}
                {errors.length > 0 && <h1>Error: {errors}</h1>}

                <hr />
                <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
                    <TableHead sx={{ backgroundColor: '#81d4fa' }}>
                        <TableRow>
                            <TableCell>Address</TableCell>
                            <TableCell align="right">RegistryPhoneNumber</TableCell>
                            <TableCell align="right">IsActive</TableCell>
                            <TableCell align="right">Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {offices.map((row) => (
                            <OfficeTableRow
                                key={row.id}
                                entity={row}
                                delete={deleteOfficeById}
                                open={openOfficeDetails}
                            />
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>

    );
};

export default OfficeTable;