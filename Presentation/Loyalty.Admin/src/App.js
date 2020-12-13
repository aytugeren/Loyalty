import React from "react";
import "./App.css";
import { Container } from "reactstrap";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import Customer from "./pages/Customer";
import NotFound from "./pages/NotFound";
import Dashboard from "./pages/Dashboard";
import PointSystem from "./pages/PointSystem";
import ShopSettings from "./pages/ShopSettings";
import Login from "./pages/Login";

function App() {
  return (
    <>
      <Router>
      <Navbar />
        <Container className="bodyContainer" fluid={true}>
          
          <div className="bodyHome">
            <Switch>
              <Route exact path="/login" component={Login} />
              <Route path="/dashboard" component={Dashboard} />
              <Route path="/customer" component={Customer} />
              <Route path="/pointsystem" component={PointSystem} />
              <Route path="/shopsettings" component={ShopSettings} />
              <Route component={NotFound} />
            </Switch>
          </div>
        </Container>
      </Router>
    </>
  );
}
export default App;
