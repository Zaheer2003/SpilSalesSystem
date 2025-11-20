import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { getItems } from '../../services/api';

export const fetchItems = createAsyncThunk(
  'items/fetchItems',
  async (_, { rejectWithValue }) => {
    try {
      const response = await getItems();
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

const itemSlice = createSlice({
  name: 'items',
  initialState: {
    list: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchItems.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchItems.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.list = action.payload;
      })
      .addCase(fetchItems.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      });
  },
});

export default itemSlice.reducer;
