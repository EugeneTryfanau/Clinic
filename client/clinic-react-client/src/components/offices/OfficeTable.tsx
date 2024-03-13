import { useEffect } from 'react';
import { CircularProgress, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { fetchOffices } from '../../store/reducers/offices/ActionCreators';

const OfficeTable = () => {

    const { offices, isLoading, error } = useAppSelector(state => state.officeReducer)
    const dispatch = useAppDispatch()

    useEffect(() => {
        dispatch(fetchOffices())
        console.log(dispatch, offices, isLoading, error)
    }, []);

    

    return (
        <TableContainer component={Paper} >
            <Typography
                sx={{ flex: '1 1 100%' }}
                padding="10px"
                variant="h6"
                component="div"
            >
                Offices
            </Typography>

            {isLoading && <CircularProgress />}
            {error && <h1>{error}</h1>}

            <hr />
            <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
                <TableHead>
                    <TableRow>
                        <TableCell>Id</TableCell>
                        <TableCell align="right">Address</TableCell>
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
                            <TableCell component="th" scope="row">
                                {row.id}
                            </TableCell>
                            <TableCell align="right">{row.address}</TableCell>
                            <TableCell align="right">{row.registryPhoneNumber}</TableCell>
                            <TableCell align="right">{row.isActive}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default OfficeTable;