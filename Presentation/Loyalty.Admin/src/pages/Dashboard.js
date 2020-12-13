import React, { useState, useEffect } from "react";
import { Table, Input } from "reactstrap";
import Customer from "./Customer";
import axios from "axios";
import Cookies from 'universal-cookie';
import ExitOwner from "./Owner/ExitOwner";
import '../css/Dashboard.css'
import EditCustomer from "./Customer/EditCustomer";
import {Checkbox} from '@material-ui/core';

function Example(props) {
  const [search, setSearch] = useState("");
  const [items, setItems] = useState([]);
  const [selected, setSelected] = useState(false);
  const [selectedRows, setSelectedRows] = useState([]);

  const cookies = new Cookies();
  const handleSearch = (keyword) => setSearch(keyword);
  
  useEffect(() => {
    if(!cookies.get('id')){
      props.history.push('./login');
    }
    refreshCustomerList();
  }, [])

  const customerAPI = (url = 'http://localhost:53055/api/Customer/GetCustomers') =>{
    return {
      fetchAll: () => axios.post(url)
    }
  }

  const selectRow = (e) => {
    let selectedRowTemp = selectedRows;
    if (e.target.checked) {
      var filtered = items.filter(v=>{
        return v.Id === e.target.valuel
      });
      selectedRows.push(filtered[0].Id);
      setSelectedRows(selectedRowTemp);
    }
    else {
      var filtered = selectedRowTemp.filter(v=>{
        return v !== e.target.value;
      });
      setSelectedRows(filtered);
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
      <div className="containerDashboard">
        <div className="searchBox">
        <Input
          type="search"
          placeholder="Find Customer"
          value={search}
          onChange={(e) => handleSearch(e.target.value)}
        />
        </div>
      </div>
      <div className="rightContainer">
      <div className="exitButton">
        <ExitOwner/>
      </div>
      <div className="addButtonPrefix">
        <Customer  refresh={refresh}/>
      </div>
      <div>
        <EditCustomer />
      </div>
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
               <tr key={item.id} >
               <th scope="row"><Checkbox name="checkBox" color="primary" value={item.id} checked={selected} onChange={(e) => selectRow(e)} /></th>
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
