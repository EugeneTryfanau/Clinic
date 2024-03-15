import { StateCreator } from 'zustand'
import { IOffice } from '../models/IOffice';
import { getOffices } from '../services/OffisesService';

export interface OfficeSlice {
    offices: IOffice[]
    isLoading: boolean
    errors: string[]
    fetchOffices: () => Promise<void>
}

export const getOfficeSlice: StateCreator<OfficeSlice> = (set) => ({
    offices: [],
    isLoading: false,
    errors: [],
    fetchOffices: async () => {
        const response = await getOffices();
        response.code === "error" ? 
            set({ errors: [response.code, response.error.message] }) 
            : 
            set({ offices: response.data });
    }
})