import { create } from 'zustand'
import { persist } from 'zustand/middleware';
import { immer } from 'zustand/middleware/immer';
import { devtools } from 'zustand/middleware';
import { IOffice } from '../models/IOffice';
import { getOffices } from '../services/OffisesService';

export interface OfficeState{
    offices: IOffice[]
    isLoading: boolean
    errors: string[]
    fetchOffices: () => Promise<void>
}

export const useOfficeStore = create<OfficeState>()(persist(devtools(immer((set) => ({
    offices: [],
    isLoading: false,
    errors: [],
    fetchOffices: async () => {
        const response = await getOffices();
        response.code === "error" ? { errors: [response.error] } : set({offices: response.data});    
    }
}))), {name: 'global-store'}))