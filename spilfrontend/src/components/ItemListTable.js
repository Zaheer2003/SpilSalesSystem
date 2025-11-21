import React from 'react';

const ItemListTable = ({ items, itemCodeOptions, handleItemChange, handleRemoveItem, onAddItem }) => {

  const calculateTotals = () => {
    let totalExcl = 0;
    let totalTax = 0;
    let totalIncl = 0;

    items.forEach(item => {
      const exclAmount = item.quantity * item.price;
      const taxAmount = exclAmount * (item.taxRate / 100);
      const inclAmount = exclAmount + taxAmount;

      totalExcl += exclAmount;
      totalTax += taxAmount;
      totalIncl += inclAmount;
    });

    return { totalExcl, totalTax, totalIncl };
  };

  const { totalExcl, totalTax, totalIncl } = calculateTotals();

  return (
    <div className="overflow-x-auto bg-white shadow-md rounded my-6">
      <table className="min-w-full border-collapse table-auto">
        <thead>
          <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
            <th className="py-3 px-3 text-left">Item Code</th>
            <th className="py-3 px-3 text-left">Description</th>
            <th className="py-3 px-3 text-left">Note</th>
            <th className="py-3 px-3 text-center">Quantity</th>
            <th className="py-3 px-3 text-center">Price</th>
            <th className="py-3 px-3 text-center">Tax (%)</th>
            <th className="py-3 px-3 text-right">Excl Amount</th>
            <th className="py-3 px-3 text-right">Tax Amount</th>
            <th className="py-3 px-3 text-right">Incl Amount</th>
            <th className="py-3 px-3 text-center">Actions</th>
          </tr>
        </thead>
        <tbody className="text-gray-600 text-sm font-light">
          {items.length === 0 ? (
            <tr className="border-b border-gray-200 hover:bg-gray-100">
              <td colSpan="10" className="py-3 px-6 text-center">No items added yet.</td>
            </tr>
          ) : (
            items.map((item, index) => {
              const exclAmount = item.quantity * item.price;
              const taxAmount = exclAmount * (item.taxRate / 100);
              const inclAmount = exclAmount + taxAmount;

              return (
                <tr key={item.id} className="border-b border-gray-200 hover:bg-gray-100">
                  <td className="py-2 px-3 text-left">
                    <select
                      className="block w-full bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 p-1"
                      value={item.itemCode}
                      onChange={(e) => handleItemChange(item.id, 'itemCode', e.target.value)}
                    >
                      <option value="">Select Item</option>
                      {itemCodeOptions.map(option => (
                        <option key={option.itemCode} value={option.itemCode} className="text-gray-900">
                          {`${option.itemCode} - ${option.name}`}
                        </option>
                      ))}
                    </select>
                  </td>
                  <td className="py-2 px-3 text-left">
                    <input
                      type="text"
                      className="block w-full bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg p-1"
                      value={item.description}
                      onChange={(e) => handleItemChange(item.id, 'description', e.target.value)}
                    />
                  </td>
                  <td className="py-2 px-3 text-left">
                    <input
                      type="text"
                      className="block w-full bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg p-1"
                      value={item.note}
                      onChange={(e) => handleItemChange(item.id, 'note', e.target.value)}
                    />
                  </td>
                  <td className="py-2 px-3 text-center">
                    <input
                      type="number"
                      className="block w-full bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg p-1 text-center"
                      value={item.quantity}
                      onChange={(e) => handleItemChange(item.id, 'quantity', isNaN(parseFloat(e.target.value)) ? 0 : parseFloat(e.target.value))}
                    />
                  </td>
                  <td className="py-2 px-3 text-center">
                    <input
                      type="number"
                      className="block w-full bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg p-1 text-center"
                      value={item.price}
                      onChange={(e) => handleItemChange(item.id, 'price', isNaN(parseFloat(e.target.value)) ? 0 : parseFloat(e.target.value))}
                    />
                  </td>
                  <td className="py-2 px-3 text-center">
                    <input
                      type="number"
                      className="block w-full bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg p-1 text-center"
                      value={item.taxRate}
                      onChange={(e) => handleItemChange(item.id, 'taxRate', isNaN(parseFloat(e.target.value)) ? 0 : parseFloat(e.target.value))}
                    />
                  </td>
                  <td className="py-2 px-3 text-right">{exclAmount.toFixed(2)}</td>
                  <td className="py-2 px-3 text-right">{taxAmount.toFixed(2)}</td>
                  <td className="py-2 px-3 text-right">{inclAmount.toFixed(2)}</td>
                  <td className="py-2 px-3 text-center">
                    <button
                      className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 rounded text-xs"
                      onClick={() => handleRemoveItem(item.id)}
                    >
                      Remove
                    </button>
                  </td>
                </tr>
              );
            })
          )}
        </tbody>
        <tfoot>
          <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
            <td colSpan="8" className="py-2 px-3 text-right font-bold">Total Excl:</td>
            <td className="py-2 px-3 text-right font-bold">{totalExcl.toFixed(2)}</td>
            <td className="py-2 px-3"></td> {/* Empty cell for actions column */}
          </tr>
          <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
            <td colSpan="8" className="py-2 px-3 text-right font-bold">Total Tax:</td>
            <td className="py-2 px-3 text-right font-bold">{totalTax.toFixed(2)}</td>
            <td className="py-2 px-3"></td> {/* Empty cell for actions column */}
          </tr>
          <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
            <td colSpan="8" className="py-2 px-3 text-right font-bold">Total Incl:</td>
            <td className="py-2 px-3 text-right font-bold">{totalIncl.toFixed(2)}</td>
            <td className="py-2 px-3"></td> {/* Empty cell for actions column */}
          </tr>
          <tr>
            <td colSpan="10" className="py-3 px-3 text-left">
              <button
                type="button"
                className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                onClick={onAddItem}
              >
                Add Item
              </button>
            </td>
          </tr>
        </tfoot>
      </table>
    </div>
  );
};

export default ItemListTable;
