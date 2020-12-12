import React from "react";
import "./App.css";
import Navbar from "./components/Navbar";
import { BrowserRouter as Router, Switch, Route} from "react-router-dom";
import Home from "./pages/Home";
import Customer from "./pages/Customer";
import NotFound from "./pages/NotFound";
import Dashboard from "./pages/Dashboard";
import PointSystem from "./pages/PointSystem";
import ShopSettings from "./pages/ShopSettings";

function App() {
  return (
    <>
      <Router>
      <Navbar />
      <div className="bodyHome">
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/dashboard" component={Dashboard} />
          <Route path="/customer" component={Customer} />
          <Route path="/pointsystem" component={PointSystem} />
          <Route path="/shopsettings" component={ShopSettings} />
          <Route component={NotFound} />
        </Switch>
        </div>
        </Router>
        </>
  );
}
export default App;
