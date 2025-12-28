import Navbar from './components/navbar'
import Home from './pages/home'
import About from './pages/about'
import NotFound from './pages/f404'
import Person from './components/person/person'
import { Routes, Route } from "react-router-dom";
import { Toaster } from 'react-hot-toast';

const App = () => {
  return (
    <>
      <Navbar />

      <Routes>
        <Route index element={<Home />} />
        <Route path="about" element={<About />} />
        <Route path="person" element={<Person />} />
        <Route path="*" element={<NotFound />} />

      </Routes>

      <Toaster />
    </>
  )
}

export default App