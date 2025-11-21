import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';

import { getOrders, getOrderById, createOrder, updateOrder, deleteOrder } from '../../services/api';


export const fetchOrders = createAsyncThunk(
  'salesOrder/fetchOrders',
  async (_, { rejectWithValue }) => {
    try {
      const response = await getOrders();
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

export const fetchOrderById = createAsyncThunk(
  'salesOrder/fetchOrderById',
  async (orderId, { rejectWithValue }) => {
    try {
      const response = await getOrderById(orderId);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);


export const createOrderAsync = createAsyncThunk(
  'salesOrder/createOrder',
  async (orderData, { rejectWithValue }) => {
    try {
      const response = await createOrder(orderData);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);


export const updateOrderAsync = createAsyncThunk(
  'salesOrder/updateOrder',
  async ({ id, orderData }, { rejectWithValue }) => {
    try {
      const response = await updateOrder(id, orderData);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);


export const deleteOrderAsync = createAsyncThunk(
  'salesOrder/deleteOrder',
  async (orderId, { rejectWithValue }) => {
    try {
      await deleteOrder(orderId);
      return orderId; 
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

const initialState = {
  items: [], 
  orders: [],
  ordersStatus: 'idle', 
  ordersError: null,
  currentOrder: null, 
  currentOrderStatus: 'idle', 
  currentOrderError: null,
  saveOrderStatus: 'idle', 
  saveOrderError: null,
};

const salesOrderSlice = createSlice({
  name: 'salesOrder',
  initialState,
  reducers: {
    addItem: (state, action) => {
      state.items.push(action.payload);
    },
    removeItem: (state, action) => {
      state.items = state.items.filter(item => item.id !== action.payload);
    },
    updateItem: (state, action) => {
      const { id, field, value } = action.payload;
      const itemToUpdate = state.items.find(item => item.id === id);
      if (itemToUpdate) {
        if (field === 'itemCode') {
          const selectedItem = action.payload.allItems.find(dataItem => dataItem.itemCode === parseInt(value, 10));
          if (selectedItem) {
            Object.assign(itemToUpdate, {
              id: selectedItem.id, // Update the frontend item's ID with the backend item's ID
              itemCode: value,
              description: selectedItem.description || '',
              note: selectedItem.note || '',
              price: selectedItem.price || 0,
              taxRate: selectedItem.taxRate || 0,
            });
          } else {
            itemToUpdate[field] = value;
          }
        } else {
          itemToUpdate[field] = value;
        }
      }
    },
    setInitialItems: (state, action) => {
      state.items = action.payload;
    },
    setItemCodeOptions: (state, action) => {
      state.itemCodeOptions = action.payload;
    },
    clearCurrentOrder: (state) => {
      state.currentOrder = null;
      state.items = [];
      state.currentOrderStatus = 'idle';
      state.currentOrderError = null;
      state.saveOrderStatus = 'idle';
      state.saveOrderError = null;
    }
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchOrders.pending, (state) => {
        state.ordersStatus = 'loading';
      })
      .addCase(fetchOrders.fulfilled, (state, action) => {
        state.ordersStatus = 'succeeded';
        state.orders = action.payload;
      })
      .addCase(fetchOrders.rejected, (state, action) => {
        state.ordersStatus = 'failed';
        state.ordersError = action.payload;
      })
      .addCase(fetchOrderById.pending, (state) => {
        state.currentOrderStatus = 'loading';
      })
      .addCase(fetchOrderById.fulfilled, (state, action) => {
        state.currentOrderStatus = 'succeeded';
        state.currentOrder = action.payload;
        state.items = action.payload.orderItems || [];
      })
      .addCase(fetchOrderById.rejected, (state, action) => {
        state.currentOrderStatus = 'failed';
        state.currentOrderError = action.payload;
      })
      .addCase(createOrderAsync.pending, (state) => {
        state.saveOrderStatus = 'loading';
      })
      .addCase(createOrderAsync.fulfilled, (state, action) => {
        state.saveOrderStatus = 'succeeded';
        state.orders.push(action.payload); 
        state.currentOrder = action.payload; 
      })
      .addCase(createOrderAsync.rejected, (state, action) => {
        state.saveOrderStatus = 'failed';
        state.saveOrderError = action.payload;
      })
      .addCase(updateOrderAsync.pending, (state) => {
        state.saveOrderStatus = 'loading';
      })
      .addCase(updateOrderAsync.fulfilled, (state, action) => {
        state.saveOrderStatus = 'succeeded';
        state.currentOrder = action.payload; 
        const index = state.orders.findIndex(order => order.id === action.payload.id);
        if (index !== -1) {
          state.orders[index] = action.payload;
        }
      })
      .addCase(updateOrderAsync.rejected, (state, action) => {
        state.saveOrderStatus = 'failed';
        state.saveOrderError = action.payload;
      })
      .addCase(deleteOrderAsync.pending, (state) => {
      })
      .addCase(deleteOrderAsync.fulfilled, (state, action) => {
        state.orders = state.orders.filter(order => order.id !== action.payload);
        if (state.currentOrder && state.currentOrder.id === action.payload) {
          state.currentOrder = null; 
          state.items = [];
        }
      })
      .addCase(deleteOrderAsync.rejected, (state, action) => {
        console.error("Failed to delete order:", action.payload);
      });
  },
});

export const { addItem, removeItem, updateItem, setInitialItems, setItemCodeOptions, clearCurrentOrder } = salesOrderSlice.actions;
export default salesOrderSlice.reducer;
