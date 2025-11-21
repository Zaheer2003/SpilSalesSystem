import React from 'react';
import Combobox from './Combobox'; // Import the new Combobox component

function CustomerCard({ customers, selectedCustomer, onSelectCustomer }) {

  return (
    <div className="bg-gray-50 p-4 rounded-md shadow-sm">
      <h2 className="text-xl font-semibold mb-4">Customer Details</h2>
      <div className="mb-4 flex items-center">
        <label htmlFor="customerName" className="w-1/3 text-gray-700 text-sm font-bold mr-2">
          Customer Name:
        </label>
        <div className="w-2/3"> {/* Wrapper div for Combobox */}
          <Combobox
            items={customers} // Use passed customers list
            displayKey="name" // Assuming Customer entity has CustomerName
            onSelectItem={onSelectCustomer}
            initialSelectedItem={selectedCustomer}
          />
        </div>
      </div>
      <div className="mb-4 flex items-center">
        <label htmlFor="address1" className="w-1/3 text-gray-700 text-sm font-bold mr-2">
          Address 1:
        </label>
        <input
          type="text"
          id="address1"
          name="address1"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          value={selectedCustomer ? selectedCustomer.address1 : ''}
          readOnly
        />
      </div>
      <div className="mb-4 flex items-center">
        <label htmlFor="address2" className="w-1/3 text-gray-700 text-sm font-bold mr-2">
          Address 2:
        </label>
        <input
          type="text"
          id="address2"
          name="address2"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          value={selectedCustomer ? selectedCustomer.address2 : ''}
          readOnly
        />
      </div>
      <div className="mb-4 flex items-center">
        <label htmlFor="city" className="w-1/3 text-gray-700 text-sm font-bold mr-2">
          City:
        </label>
        <input
          type="text"
          id="city"
          name="city"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          value={selectedCustomer ? selectedCustomer.city : ''}
          readOnly
        />
      </div>
      <div className="mb-4 flex items-center">
        <label htmlFor="postalCode" className="w-1/3 text-gray-700 text-sm font-bold mr-2">
          Postal Code:
        </label>
        <input
          type="text"
          id="postalCode"
          name="postalCode"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          value={selectedCustomer ? selectedCustomer.postalCode : ''}
          readOnly
        />
      </div>
    </div>
  );
}

export default CustomerCard;
