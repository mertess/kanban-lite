import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState } from './store'

interface StageState {
    value: number //test data
}

const initialState: StageState = {
    value: 0
}

export const stageSlice = createSlice({
    name: 'stage',
    initialState: initialState,
    reducers: {
        createStage: (state, action: PayloadAction) => {

        },
        deleteStage: (state, action: PayloadAction) => {

        },
        updateStage: (state, action: PayloadAction) => {

        }
    }
})

export const { createStage, deleteStage, updateStage } = stageSlice.actions

export const selectValue = (state: RootState) => state.stage.value;

export default stageSlice.reducer