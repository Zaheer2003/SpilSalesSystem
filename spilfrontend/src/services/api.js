import axios from 'axios';

const API_BASE_URL = 'https://localhost:7218/api'; 

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getOrders = () => api.get('/Order');
export const getOrderById = (id) => api.get(`/Order/${id}`);
export const createOrder = (order) => api.post('/Order', order);
export const updateOrder = (id, order) => api.put(`/Order/${id}`, order);
export const deleteOrder = (id) => api.delete(`/Order/${id}`);

export const getItems = () => api.get('/Item');
export const getItemById = (id) => api.get(`/Item/${id}`);
export const createItem = (item) => api.post('/Item', item);
export const updateItem = (id, item) => api.put(`/Item/${id}`, item);
export const deleteItem = (id) => api.delete(`/Item/${id}`);

export const getClients = () => api.get('/Client');
export const getClientById = (id) => api.get(`/Client/${id}`);
export const createClient = (client) => api.post('/Client', client);
export const updateClient = (id, client) => api.put(`/Client/${id}`, client);
export const deleteClient = (id) => api.delete(`/Client/${id}`);

export default api;
