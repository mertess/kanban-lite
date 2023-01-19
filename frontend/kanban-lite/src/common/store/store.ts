import { configureStore } from '@reduxjs/toolkit'
import stageSlice from './stageSlice'

const store = configureStore({
    reducer: {
        stage: stageSlice
    }
})

export default store

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred types in reducer of configured store
export type AppDispatch = typeof store.dispatch