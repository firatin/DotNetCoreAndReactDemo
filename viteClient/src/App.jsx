import React from 'react'
import Navbar from './components/Navbar'
import Home from './pages/home'
import About from './pages/about'
import NotFound404 from './pages/f404'
import Person from './components/person/person'
import { Routes, Route } from "react-router";



const App = () => {
  return (
    <>
      <Navbar />
      <Routes>
        <Route index element={<Home />} />
        <Route path="about" element={<About />} />
        <Route path="Person" element={<Person />} />
        <Route path="*" element={<NotFound404 />} />
      </Routes>
    </>
  )
}

export default App