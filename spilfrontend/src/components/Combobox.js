import React, { useState, useEffect, useRef } from 'react';

function Combobox({ items, displayKey, onSelectItem, initialSelectedItem }) {
  const [inputValue, setInputValue] = useState('');
  const [filteredSuggestions, setFilteredSuggestions] = useState([]);
  const [showSuggestions, setShowSuggestions] = useState(false);
  const wrapperRef = useRef(null);

  // Initialize input value and selected item
  useEffect(() => {
    if (initialSelectedItem && initialSelectedItem[displayKey]) {
      setInputValue(initialSelectedItem[displayKey] || '');
    } else {
      setInputValue('');
    }
  }, [initialSelectedItem, displayKey]);

  // Handle clicks outside to close suggestions
  useEffect(() => {
    function handleClickOutside(event) {
      if (wrapperRef.current && !wrapperRef.current.contains(event.target)) {
        setShowSuggestions(false);
      }
    }
    document.addEventListener('mousedown', handleClickOutside);
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, [wrapperRef]);


  const handleInputChange = (event) => {
    const value = event.target.value;
    setInputValue(value);

    if (value.length > 0) {
      const suggestions = items.filter((item) =>
        item[displayKey].toLowerCase().includes(value.toLowerCase())
      );
      setFilteredSuggestions(suggestions);
      setShowSuggestions(true);
    } else {
      setFilteredSuggestions(items); // Show all if input is empty
      setShowSuggestions(true);
    }
  };

  const handleSelectSuggestion = (item) => {
    onSelectItem(item); // Callback to parent component first
    setInputValue(''); // Clear input after selection
    setFilteredSuggestions([]); // Clear suggestions after selection
    setShowSuggestions(false);
  };

  const toggleSuggestions = () => {
    // If suggestions are currently hidden and we are about to show them
    if (!showSuggestions) {
      if (inputValue.length > 0) {
        const suggestions = items.filter((item) =>
          item[displayKey].toLowerCase().includes(inputValue.toLowerCase())
        );
        setFilteredSuggestions(suggestions);
      } else {
        setFilteredSuggestions(items); // Show all if input is empty
      }
    }
    setShowSuggestions((prev) => !prev);
  };

  return (
    <div className="relative w-full" ref={wrapperRef}>
      <div className="flex items-center border rounded shadow appearance-none w-full"> {/* Flex container for input and button */}
        <input
          type="text"
          className="py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline flex-grow" // flex-grow to take available space
          placeholder="Type to search or select"
          value={inputValue}
          onChange={handleInputChange}
          onFocus={() => {
            if (!showSuggestions) { // Only re-evaluate if suggestions are currently hidden
                if (inputValue.length > 0) {
                    const suggestions = items.filter((item) =>
                        item[displayKey].toLowerCase().includes(inputValue.toLowerCase())
                    );
                    setFilteredSuggestions(suggestions);
                } else {
                    setFilteredSuggestions(items); // Show all if input empty on focus
                }
                setShowSuggestions(true);
            }
          }}
        />
        <button
          type="button"
          onClick={toggleSuggestions}
          className="p-2 bg-gray-200 hover:bg-gray-300 focus:outline-none focus:shadow-outline rounded-r"
        >
          {/* Simple SVG for a dropdown arrow */}
          <svg className="w-4 h-4 text-gray-700" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 9l-7 7-7-7"></path>
          </svg>
        </button>
      </div>

      {showSuggestions && filteredSuggestions.length > 0 && (
        <ul className="absolute z-10 w-full bg-white border border-gray-300 rounded mt-1 shadow-lg max-h-60 overflow-y-auto">
          {filteredSuggestions.map((item) => (
            <li
              key={item.id} // Assuming items have a unique 'id'
              className="px-3 py-2 cursor-pointer hover:bg-gray-200 text-gray-900"
              onClick={() => handleSelectSuggestion(item)}
            >
              {item[displayKey]}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default Combobox;
