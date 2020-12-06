import React, { useState, useEffect } from 'react';
import axios from "axios";

function Home() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

  useEffect(() => {
    refreshCustomerList();
  }, [])

const customerAPI = (url = 'http://localhost:53055/api/Customer/GetCustomers') => {
  return {
    fetchAll: () => axios.post(url)
  }
}


function refreshCustomerList (){
  customerAPI().fetchAll().then(res => {
    setItems(res.data);
  }).catch(err => console.log(err));
}
    return (
      <div className='home'>
        <ul>
        {items.map(item => <li>{item.firstname}</li>)}
          </ul>
      </div>
    );
  }
export default Home;
