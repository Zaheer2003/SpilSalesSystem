import { configureStore } from '@reduxjs/toolkit';
import exampleReducer from './slices/exampleSlice';
import salesOrderReducer from './slices/salesOrderSlice';
import itemReducer from './slices/itemSlice'; 
import customerReducer from './slices/customerSlice'; 

export const store = configureStore({
  reducer: {
    example: exampleReducer,
    salesOrder: salesOrderReducer,
    items: itemReducer,
    customers: customerReducer, 
  },
});
