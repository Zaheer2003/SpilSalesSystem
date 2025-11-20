import { configureStore } from '@reduxjs/toolkit';

import salesOrderReducer from './slices/salesOrderSlice';
import itemReducer from './slices/itemSlice'; 
import customerReducer from './slices/customerSlice'; 

export const store = configureStore({
  reducer: {

    salesOrder: salesOrderReducer,
    items: itemReducer,
    customers: customerReducer, 
  },
});
