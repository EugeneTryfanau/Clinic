import { combineReducers, configureStore } from '@reduxjs/toolkit';
import officeReducer from './reducers/offices/OfficeSlice'

const rootReducer = combineReducers({
    officeReducer,
})

export const setupStore = () => {
    return configureStore({
        reducer: rootReducer
    })
}

export type RootState = ReturnType<typeof rootReducer>
export type AppClinic = ReturnType<typeof setupStore>
export type AppDispatch = AppClinic['dispatch']
