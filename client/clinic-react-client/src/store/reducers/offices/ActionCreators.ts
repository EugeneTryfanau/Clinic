import { createAsyncThunk } from "@reduxjs/toolkit";
import OfficesService from "../../../services/OffisesService";

type ErrorWithMessage = { message: string };

export const fetchOffices = createAsyncThunk(
    'office/getAll',
    async (_, thunkAPI) => {
        try {
            const response = await OfficesService.getAll()
            return response;
        } catch (e: unknown) {
            if ((e as ErrorWithMessage).message) {
                return thunkAPI.rejectWithValue((e as ErrorWithMessage).message);
            }
        }
    }
)