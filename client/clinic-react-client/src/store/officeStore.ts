import { StateCreator } from 'zustand'
import { IOffice } from '../models/IOffice';
import { createOffice, deleteOffice, getByIdOffice, getOffices, updateOffice } from '../services/OffisesService';

export interface OfficeSlice {
    offices: IOffice[],
    office: IOffice,
    isLoading: boolean
    errors: string[]
    fetchOffices: () => Promise<void>
    getOfficeById: (id: string) => Promise<void>
    createOffice: (office: IOffice) => Promise<void>
    updateOffice: (id: string, office: IOffice) => Promise<void>
    deleteOffice: (id: string) => Promise<void>
}

export const getOfficeSlice: StateCreator<OfficeSlice> = (set, get) => ({
    offices: [],
    office: {} as IOffice,
    isLoading: false,
    errors: [],
    fetchOffices: async () => {
        set({ isLoading: true });
        const response = await getOffices();
        response.code === "error" ? 
            set({ errors: [response.code, response.error.message], isLoading: false }) 
            : 
            set({ offices: response.data, isLoading: false });
    },
    getOfficeById: async (id: string) => {
        set({ isLoading: true });
        const response = await getByIdOffice({id});
        if (response.code === "error") {
            set({ errors: [response.code, response.error.message], isLoading: false });
        } else {
            set({ office: response.data, isLoading: false });
        }
    },
    createOffice: async (office: IOffice) => {
        set({ isLoading: true });
        const response = await createOffice({entity: office});
        if (response.code === "error") {
            set({ errors: [response.code, response.error.message], isLoading: false });
        } else {
            set({ offices: [...get().offices, response.data], office: response.data, isLoading: false });
        }
    },
    updateOffice: async (id: string, office: IOffice) => {
        set({ isLoading: true });
        const response = await updateOffice({id: id, entity: office});
        if (response.code === "error") {
            set({ errors: [response.code, response.error.message], isLoading: false });
        } else {
            set({ offices: get().offices.map(o => o.id === id ? response.data : o), office: response.data, isLoading: false });
        }
    },
    deleteOffice: async (id: string) => {
        set({ isLoading: true });
        const response = await deleteOffice({id: id});
        if (response.code === "error") {
            set({ errors: [response.code, response.error.message], isLoading: false });
        } else {
            set({ offices: get().offices.filter(o => o.id !== id), office: {} as IOffice, isLoading: false });
        }
    }
})