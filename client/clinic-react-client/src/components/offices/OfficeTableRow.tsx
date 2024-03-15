import { TableCell, TableRow } from "@mui/material";
import { IOffice } from "../../models/IOffice";

const OfficeTableRow: React.FC<StandartParamsWithEntity<IOffice>> = (props) => {
    return (
        <TableRow
            key={props.entity.id}
            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
        >
            <TableCell component="th" scope="row">{props.entity.address}</TableCell>
            <TableCell align="right">{props.entity.registryPhoneNumber}</TableCell>
            <TableCell align="right">
                {props.entity.isActive == 0 ? 'Active' : props.entity.isActive == 1 ? 'Inactive' : 'None'}
            </TableCell>
        </TableRow>
    );
}

export default OfficeTableRow;