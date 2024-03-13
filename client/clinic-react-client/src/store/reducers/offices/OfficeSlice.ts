import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IOffice } from "../../../models/IOffice";
import { fetchOffices } from "./ActionCreators";

interface IOfficeState {
    offices: IOffice[];
    office: IOffice;
    isLoading: boolean;
    error: string;
}

const initialState: IOfficeState = {
    offices: [] as IOffice[],
    office: {} as IOffice,
    isLoading: false,
    error: '',  
}

export const officeSlice = createSlice({
    name: 'office',
    initialState,
    reducers: {
        [fetchOffices.fulfilled.type]: (state: { isLoading: boolean; error: string; offices: IOffice[]; }, action: PayloadAction<Array<IOffice>>) => {
            state.isLoading = false;
            state.error = '';
            state.offices = action.payload;
        },
        [fetchOffices.pending.type]: (state: { isLoading: boolean; }) => {
            state.isLoading = true;
        },
        [fetchOffices.rejected.type]: (state: { isLoading: boolean; error: string; }, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default officeSlice.reducer;