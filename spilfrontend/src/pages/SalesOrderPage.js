import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import CustomerCard from '../components/CustomerCard';
import InvoiceCard from '../components/InvoiceCard';
import ItemListTable from '../components/ItemListTable';

import {
  addItem,
  removeItem,
  updateItem,
  setInitialItems,
  fetchOrderById,
  createOrderAsync,
  updateOrderAsync,
  clearCurrentOrder,
} from '../redux/slices/salesOrderSlice';
import { fetchItems } from '../redux/slices/itemSlice';
import { fetchCustomers } from '../redux/slices/customerSlice';
import { getNextInvoiceNumber } from '../services/api';

function SalesOrderPage() {
  const { orderId } = useParams();
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const items = useSelector(state => state.salesOrder.items);
  const salesOrderItems = useSelector(state => state.items.list); 
  const customersList = useSelector(state => state.customers.list); 
  const currentOrder = useSelector(state => state.salesOrder.currentOrder);
  const currentOrderStatus = useSelector(state => state.salesOrder.currentOrderStatus);
  const currentOrderError = useSelector(state => state.salesOrder.currentOrderError);
  const saveOrderStatus = useSelector(state => state.salesOrder.saveOrderStatus);
  const saveOrderError = useSelector(state => state.salesOrder.saveOrderError);

  const itemCodeOptions = salesOrderItems.map(item => ({ ...item, name: item.description }));

  
  const [customerDetails, setCustomerDetails] = useState({
    customerId: '', 
    name: '',
    address1: '',
    address2: '',
    city: '',
    postalCode: '',
  });

  const [invoiceDetails, setInvoiceDetails] = useState({
    invoiceNo: '',
    invoiceDate: new Date().toISOString().split('T')[0],
    referenceNo: '',
  });

  const [showSuccessMessage, setShowSuccessMessage] = useState(false);


  
  useEffect(() => {
    dispatch(fetchItems());
    dispatch(fetchCustomers());

    if (orderId) {
      dispatch(fetchOrderById(orderId));
    } else {
      dispatch(clearCurrentOrder()); 
      dispatch(setInitialItems([
        { id: Date.now(), itemCode: '', description: '', note: '', quantity: 1, price: 0.00, taxRate: 10 },
      ]));
      // Fetch next invoice number
      const fetchNextInvoiceNumber = async () => {
        try {
          const response = await getNextInvoiceNumber();
          setInvoiceDetails(prev => ({ ...prev, invoiceNo: response.data }));
        } catch (error) {
          console.error("Failed to fetch next invoice number:", error);
        }
      };
      fetchNextInvoiceNumber();
    }

    return () => {
      dispatch(clearCurrentOrder()); 
    };
  }, [orderId, dispatch]);

  useEffect(() => {
    if (currentOrderStatus === 'succeeded' && currentOrder) {
      setInitialItems(currentOrder.orderItems || []);
      setCustomerDetails({
        customerId: currentOrder.customerId || '',
        name: currentOrder.customerName || '',
        address1: currentOrder.addressLine1 || '',
        address2: currentOrder.addressLine2 || '',
        city: currentOrder.city || '',
        postalCode: currentOrder.postalCode || '',
      });
      setInvoiceDetails({
        invoiceNo: currentOrder.invoiceNo || '',
        invoiceDate: currentOrder.invoiceDate ? new Date(currentOrder.invoiceDate).toISOString().split('T')[0] : new Date().toISOString().split('T')[0],
        referenceNo: currentOrder.referenceNo || '',
      });
    }
  }, [currentOrderStatus, currentOrder, dispatch]);



  const handleItemChange = (id, field, value) => {
    dispatch(updateItem({ id, field, value, allItems: salesOrderItems })); 
  };

  const handleRemoveItem = (id) => {
    dispatch(removeItem(id));
  };

  const handleAddItem = () => {
    dispatch(addItem({ id: Date.now(), itemCode: '', description: '', note: '', quantity: 1, price: 0.00, taxRate: 10 }));
  };

  const handleCustomerSelect = (customer) => {
    setCustomerDetails({
      customerId: customer.id || '',
      name: customer.name || '',
      address1: customer.addressLine1 || '',
      address2: customer.addressLine2 || '',
      city: customer.city || '', 
      postalCode: customer.postalCode || '',
    });
  };

  const handleInvoiceChange = (e) => {
    const { name, value } = e.target;
    setInvoiceDetails(prev => ({ ...prev, [name]: value }));
  };

  const handleSaveOrder = async (e) => {
    e.preventDefault();

    const orderToSave = {
      id: orderId ? parseInt(orderId) : 0,
      customerId: customerDetails.customerId,
      invoiceDate: invoiceDetails.invoiceDate,
      invoiceNo: invoiceDetails.invoiceNo,
      refernceNo: invoiceDetails.referenceNo,
      customerName: customerDetails.name,
      addressLine1: customerDetails.address1,
      addressLine2: customerDetails.address2,
      city: customerDetails.city,
      postalCode: customerDetails.postalCode,
      totalAmount: items.reduce((acc, item) => acc + (item.quantity * item.price * (1 + item.taxRate / 100)), 0),
      totalExel: items.reduce((acc, item) => acc + (item.quantity * item.price), 0),
      totalTax: items.reduce((acc, item) => acc + (item.quantity * item.price * item.taxRate / 100), 0),
      totalIncl: items.reduce((acc, item) => acc + (item.quantity * item.price * (1 + item.taxRate / 100)), 0),
      OrderItems: items.map(item => {
        const exclAmount = item.quantity * item.price;
        const taxAmount = exclAmount * (item.taxRate / 100);
        const inclAmount = exclAmount + taxAmount;

        return {
          itemId: item.id,
          itemCode: item.itemCode,
          description: item.description,
          price: item.price, // This is UnitPrice
          taxRate: item.taxRate,
          quantity: item.quantity,
          totalExel: exclAmount,
          totalTax: taxAmount,
          totalIncl: inclAmount,
        };
      }),
    };

    if (orderId) {
      await dispatch(updateOrderAsync({ id: parseInt(orderId), orderData: orderToSave }));
    } else {
      await dispatch(createOrderAsync(orderToSave));
    }

    if (saveOrderStatus === 'succeeded') {
        setShowSuccessMessage(true);
        setTimeout(() => {
            setShowSuccessMessage(false);
            navigate('/');
        }, 2000); // Show message for 2 seconds
    } else if (saveOrderStatus === 'failed') {
        console.error("Failed to save order:", saveOrderError);
    }
  };

  if (currentOrderStatus === 'loading') {
    return <div className="p-4 text-center">Loading Order...</div>;
  }

  if (currentOrderError) {
    return <div className="p-4 text-center text-red-500">Error loading order: {currentOrderError}</div>;
  }

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4 text-center">Sales Order</h1>

      <form className="mt-4" onSubmit={handleSaveOrder}>
        {showSuccessMessage && (
          <div className="bg-green-100 border border-green-400 text-green-700 px-4 py-3 rounded relative mb-4" role="alert">
            <strong className="font-bold">Success!</strong>
            <span className="block sm:inline"> Your order has been saved. Redirecting...</span>
          </div>
        )}
        <div className="mb-4"> {/* Added mb-4 for spacing */}
          <button
            type="submit"
            className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            disabled={saveOrderStatus === 'loading'}
          >
            {saveOrderStatus === 'loading' ? 'Saving...' : 'Save Order'}
          </button>
          {saveOrderError && <p className="text-red-500 text-sm mt-2">{saveOrderError}</p>}
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          {/* Left Column: Customer Card */}
          <div className="md:col-span-1">
            <CustomerCard
              customers={customersList}
              selectedCustomer={customerDetails}
              onSelectCustomer={handleCustomerSelect}
            />
          </div>

          {/* Right Column: Invoice Card */}
          <div className="md:col-span-1">
            <InvoiceCard
              invoiceDetails={invoiceDetails}
              onInvoiceChange={handleInvoiceChange}
            />
          </div>
        </div>

        {/* Item List Table */}
        <ItemListTable
          items={items}
          itemCodeOptions={itemCodeOptions}
          handleItemChange={handleItemChange}
          handleRemoveItem={handleRemoveItem}
          onAddItem={handleAddItem}
        />
      </form>
    </div>
  );
}

export default SalesOrderPage;
