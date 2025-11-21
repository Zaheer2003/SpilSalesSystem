import React from 'react';
import { useNavigate } from 'react-router-dom';

const OrderList = ({ orders }) => {
  const navigate = useNavigate();

  const handleOrderClick = (orderId) => {
    navigate(`/sales-order/${orderId}`);
  };

  return (
    <div className="overflow-x-auto bg-white shadow-md rounded my-6">
      <table className="min-w-full border-collapse table-auto">
        <thead>
          <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
            <th className="py-3 px-6 text-left">Order ID</th>
            <th className="py-3 px-6 text-left">Customer Name</th>
            <th className="py-3 px-6 text-right">Total Amount</th>
            <th className="py-3 px-6 text-left">Date</th>
            <th className="py-3 px-6 text-center">Actions</th>
          </tr>
        </thead>
        <tbody className="text-gray-600 text-sm font-light">
          {orders.length === 0 ? (
            <tr className="border-b border-gray-200 hover:bg-gray-100">
              <td colSpan="5" className="py-3 px-6 text-center">No orders found.</td>
            </tr>
          ) : (
            orders.map((order) => (
              <tr key={order.id} className="border-b border-gray-200 hover:bg-gray-100">
                <td className="py-3 px-6 text-left whitespace-nowrap">
                  <span
                    className="text-blue-600 hover:text-blue-800 cursor-pointer underline"
                    onClick={() => handleOrderClick(order.id)}
                  >
                    {order.id}
                  </span>
                </td>
                <td className="py-3 px-6 text-left">{order.customerName}</td>
                <td className="py-3 px-6 text-right">{order.totalIncl.toFixed(2)}</td>
                <td className="py-3 px-6 text-left">{order.invoiceDate}</td>
                <td className="py-3 px-6 text-center">
                  <button
                    className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 rounded text-xs"
                    onClick={() => handleOrderClick(order.id)}
                  >
                    View
                  </button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};

export default OrderList;
