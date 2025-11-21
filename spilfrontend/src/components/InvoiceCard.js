import React from 'react';

function InvoiceCard({ invoiceDetails, onInvoiceChange }) {
  return (
    <div className="bg-gray-50 p-4 rounded-md shadow-sm">
      <h2 className="text-xl font-semibold mb-4">Invoice Details</h2>
      <div className="mb-4 flex items-center">
        <label htmlFor="invoiceNo" className="w-1/3 block text-gray-700 text-sm font-bold mr-2">
          Invoice No:
        </label>
        <input
          type="text"
          id="invoiceNo"
          name="invoiceNo"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          placeholder="Invoice Number"
          value={invoiceDetails.invoiceNo || ''}
          onChange={onInvoiceChange}
        />
      </div>
      <div className="mb-4 flex items-center">
        <label htmlFor="invoiceDate" className="w-1/3 block text-gray-700 text-sm font-bold mr-2">
          Invoice Date:
        </label>
        <input
          type="date"
          id="invoiceDate"
          name="invoiceDate"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          value={invoiceDetails.invoiceDate || ''}
          onChange={onInvoiceChange}
        />
      </div>
      <div className="mb-4 flex items-center">
        <label htmlFor="referenceNo" className="w-1/3 block text-gray-700 text-sm font-bold mr-2">
          Reference No:
        </label>
        <input
          type="text"
          id="referenceNo"
          name="referenceNo"
          className="w-2/3 shadow appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          placeholder="Reference Number"
          value={invoiceDetails.referenceNo || ''}
          onChange={onInvoiceChange}
        />
      </div>
    </div>
  );
}

export default InvoiceCard;
