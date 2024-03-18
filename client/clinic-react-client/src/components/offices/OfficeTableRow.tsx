import { Button, TableCell, TableRow } from "@mui/material";
import { IOffice } from "../../models/IOffice";

const OfficeTableRow: React.FC<StandartParamsWithEntityAndFunctions<IOffice>> = (props) => {
    return (
        <TableRow
            key={props.entity.id}
            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
        >
            <TableCell component="th" scope="row">{props.entity.id}--{props.entity.address}</TableCell>
            <TableCell align="right">{props.entity.registryPhoneNumber}</TableCell>
            <TableCell align="right">
                {props.entity.isActive == 0 ? 'None' : props.entity.isActive == 1 ? 'Active' : 'Inactive'}
            </TableCell>
            <TableCell align="right">
                <Button
                    sx={{
                        backgroundColor: "lightblue",
                        color: "white",
                        marginRight: "15px"
                    }}
                    onClick={() => props.open(props.entity.id)}
                >
                    Open
                </Button>
                <Button
                    sx={{
                        backgroundColor: "red",
                        color: "white"
                    }}
                    onClick={() => props.delete(props.entity.id)}
                >
                    Delete
                </Button>
            </TableCell>
        </TableRow>
    );
}

export default OfficeTableRow;