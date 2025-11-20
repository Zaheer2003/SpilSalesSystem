import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import OrderList from '../components/OrderList';
import { fetchOrders } from '../redux/slices/salesOrderSlice';

function HomePage() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const orders = useSelector(state => state.salesOrder.orders);
  const ordersStatus = useSelector(state => state.salesOrder.ordersStatus);
  const ordersError = useSelector(state => state.salesOrder.ordersError);

  useEffect(() => {
    if (ordersStatus === 'idle') {
      dispatch(fetchOrders());
    }
  }, [ordersStatus, dispatch]);

  const handleNewSaleClick = () => {
    navigate('/sales-order');
  };

  let content;
  if (ordersStatus === 'loading') {
    content = <p className="text-center mt-4 text-gray-700">Loading orders...</p>;
  } else if (ordersStatus === 'succeeded') {
    content = <OrderList orders={orders} />;
  } else if (ordersStatus === 'failed') {
    content = <p className="text-center mt-4 text-red-500">Error: {ordersError}</p>;
  }

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4 text-center">Home Page</h1>

      <button
        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mt-4"
        onClick={handleNewSaleClick}
      >
        New Sale
      </button>
      
      {/* List of orders */}
      {content}
    </div>
  );
}

export default HomePage;
