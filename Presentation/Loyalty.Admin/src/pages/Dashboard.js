import React, { useState, useEffect } from "react";
import { Table, Input } from "reactstrap";
import Customer from "./Customer";
import axios from "axios";

function Example() {
  const [search, setSearch] = useState("");
  const [items, setItems] = useState([]);

  const handleSearch = (keyword) => setSearch(keyword);
  
  useEffect(() => {
    refreshCustomerList();
  }, [])

  const customerAPI = (url = 'http://localhost:53055/api/Customer/GetCustomers') =>{
    return {
      fetchAll: () => axios.post(url)
    }
  }

  function refreshCustomerList (){
    customerAPI().fetchAll().then(res => {
      setItems(res.data);
    }).catch(err => console.log(err));
  }
  
  const refresh = () => refreshCustomerList();
  
  return (
    <>
      <div>
        <Customer  refresh={refresh}/>
        <Input
          type="search"
          placeholder="Find Customer"
          value={search}
          onChange={(e) => handleSearch(e.target.value)}
        />
      </div>
      <div>
        <Table hover>
          <thead>
            <tr>
              <th>#</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email</th>
            </tr>
          </thead>
          <tbody>
           
             {items.map(item => 
               <tr key={item.id}>
               <th scope="row">1</th>
               <td>{item.firstname}</td>
               <td>{item.surname}</td>
               <td>{item.email}</td>
               </tr>
              )}
          </tbody>
        </Table>
      </div>
    </>
  );
}

export default Example;
