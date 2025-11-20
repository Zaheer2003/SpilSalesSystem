import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; // Remove Link from import
import HomePage from './pages/HomePage';
import SalesOrderPage from './pages/SalesOrderPage';

function App() {
  return (
    <Router>
      <div className="min-h-screen bg-gray-100">
        <main className="container mx-auto mt-4">
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/sales-order" element={<SalesOrderPage />} />
            <Route path="/sales-order/:orderId" element={<SalesOrderPage />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
