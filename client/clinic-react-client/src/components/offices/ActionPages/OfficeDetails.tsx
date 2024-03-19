import { useParams } from "react-router-dom";
import { useGlobalStore } from "../../../store/globalStore";
import { ChangeEvent, useEffect, useState } from "react";
import { Button, CircularProgress, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, Typography } from "@mui/material";

const OfficeDetails = () => {
    const params = useParams();
    const {
        office,
        isLoading,
        errors,
        getOfficeById,
        updateOffice
    } = useGlobalStore((state) => ({
        office: state.office,
        isLoading: state.isLoading,
        errors: state.errors,
        getOfficeById: state.getOfficeById,
        updateOffice: state.updateOffice
    }));

    const [editMode, setEditMode] = useState(false);
    const [changedOffice, setChangedOffice] = useState({ ...office });


    useEffect(() => {
        const fetch = async () => {
            await getOfficeById(params.id as string);
        }
        fetch();
        setChangedOffice(office);
    }, [getOfficeById])

    const handleEdit = () => {
        setChangedOffice(office);
        setEditMode(true);
    };

    const handleChange = (e: ChangeEvent<HTMLInputElement>|SelectChangeEvent<number>) => {
        const { name, value } = e.target;
        setChangedOffice(prevData => ({
            ...prevData,
            [name]: value
        }));
    };

    const handleSave = () => {
        updateOffice(office.id as string, changedOffice)
        setEditMode(false);
    };

    const handleCancle = () => {
        setChangedOffice(office)
        setEditMode(false);
    };

    return (
        <div>
            {isLoading && <CircularProgress />}
            {errors.length > 0 && <h1>Error: {errors}</h1>}
            {editMode ? (
                <Typography
                    sx={{ flex: '1 1 100%' }}
                    padding="10px"
                    variant="h6"
                    component="div"
                    textAlign='center'
                >
                    <h1>Office</h1>
                    <h1>{office.id}</h1>
                    <h2>
                        Address:
                        <input
                            type="text"
                            name="address"
                            value={changedOffice.address}
                            onChange={handleChange}
                        />
                    </h2>
                    <h2>
                        Registry phone number:
                        <input
                            type="text"
                            name="registryPhoneNumber"
                            value={changedOffice.registryPhoneNumber}
                            onChange={handleChange}
                        />
                    </h2>
                    <h2>
                        <FormControl>
                            <InputLabel>Is active</InputLabel>
                            <Select
                                value={changedOffice.isActive}
                                label="Is active"
                                name="isActive"
                                onChange={handleChange}
                            >
                                <MenuItem value={0} disabled>None</MenuItem>
                                <MenuItem value={1}>Active</MenuItem>
                                <MenuItem value={2}>Inactive</MenuItem>
                            </Select>
                        </FormControl>
                    </h2>
                    <Button onClick={handleSave}>Save</Button>
                    <Button onClick={handleCancle}>Cancle</Button>
                </Typography>
            ) : (
                <Typography
                    sx={{ flex: '1 1 100%' }}
                    padding="10px"
                    variant="h6"
                    component="div"
                    textAlign='center'
                >
                    <h1>Office</h1>

                    <h1>{office.id}</h1>
                    <h2>Address: {office.address}</h2>
                    <h2>Registry phone number: {office.registryPhoneNumber}</h2>
                    <h2>Is active: {office.isActive == 0 ? 'None' : office.isActive == 1 ? 'Active' : 'Inactive'}</h2>
                    <Button onClick={handleEdit}>Change</Button>
                </Typography>
            )}
        </div>
    );
};

export default OfficeDetails;