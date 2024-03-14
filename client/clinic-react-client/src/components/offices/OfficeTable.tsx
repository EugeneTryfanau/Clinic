import { useEffect } from 'react';
import { CircularProgress, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useOfficeStore } from '../../store/officeStore';

const OfficeTable = () => {

    const { offices, error, isLoading, fetchOffices } = useOfficeStore(state => ({
        offices: state.offices,
        error: state.errors,
        isLoading: state.isLoading,
        fetchOffices: state.fetchOffices
    }))

    useEffect(() => {
        const fetch = async () => {
            await fetchOffices();
        }
        fetch()
    }, [fetchOffices])

    return (
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
            {error && <h1>{error}</h1>}

            <hr />
            <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
                <TableHead sx={{backgroundColor: '#81d4fa'}}>
                    <TableRow>
                        <TableCell>Address</TableCell>
                        <TableCell align="right">RegistryPhoneNumber</TableCell>
                        <TableCell align="right">IsActive</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {offices.map((row) => (
                        <TableRow
                            key={row.id}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell component="th" scope="row">{row.address}</TableCell>
                            <TableCell align="right">{row.registryPhoneNumber}</TableCell>
                            <TableCell align="right">{row.isActive == 0 ? 'Active' : row.isActive == 1 ? 'Inactive' : 'None'}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default OfficeTable;