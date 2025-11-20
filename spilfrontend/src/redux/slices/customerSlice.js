import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { getClients } from '../../services/api';

export const fetchCustomers = createAsyncThunk(
  'customers/fetchCustomers',
  async (_, { rejectWithValue }) => {
    try {
      const response = await getClients();
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

const customerSlice = createSlice({
  name: 'customers',
  initialState: {
    list: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchCustomers.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchCustomers.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.list = action.payload;
      })
      .addCase(fetchCustomers.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      });
  },
});

export default customerSlice.reducer;
