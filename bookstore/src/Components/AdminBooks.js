import { useEffect, useState } from "react";
import './Books.css';
import axios from "axios";
import UpdateBook from "./UpdateBook";
import Popup from "reactjs-popup";
import { toast } from "react-toastify";

function AdminBooks(){
    const [books,setBooks]=useState([]);
    const [bkid,setBkid]=useState(0);
    const[isPopupOpen,setPopupOpen]=useState(false);
    useEffect(()=>{
        getBooks();
    },[]);

    const edit = (id) => {
        setBkid(id);
        setPopupOpen(true);
    };

    const getBooks=()=>{
        axios.get('http://localhost:5103/api/Book/getbyuserid',{
            params: {
              id : localStorage.getItem("id")
            }
          })
          .then((response) => {
            const posts = response.data;
            setBooks(posts);
        })
        .catch(function (error) {
            console.log(error);
        })
    }
    const deleteBook= (delID) => {
      console.log(delID);
        const confirmation = window.confirm("Are you sure you want to delete the book?");
        if(confirmation){
         axios.delete('http://localhost:5103/api/Book/RemoveBook', {
         params :{
           id : delID
         },
         headers: {
           Authorization: `Bearer ${localStorage.getItem("token")}`,
         },
       })
         .then((response) => {
           toast.success("Book Deleted");
           getBooks();
         })
         .catch(function (error) {
           toast.error(error.response ? error.response.data : 'An error occurred');
         }); 
        } 
   }

    var checkBooks = books.length>0?true:false;
    return(
        <div class="books">
            <div class="displayBooks">
                {checkBooks? 
                    <div className="card-container">
                    {books.map((book, index) => (
                      <div className="card" style={{ width: "30%", marginRight: "20px" }} key={index}>
                        <img className="card-img-top" src={book.image} alt="Card image" />
                        <div className="card-body">
                          <h4 className="card-title">Title: {book.title}</h4>
                          <p className="card-text">Author: {book.author}</p>
                          <p className="card-text">Genre: {book.genre}</p>
                          <p className="card-text">Publish Date: {book.author}</p>
                          <p className="card-text">Price: $.{book.price}</p>
                          <button className="btn btn-primary" onClick={()=>edit(book.bookID)}>Edit</button>
                          <button className="btn btn-danger btnspc" onClick={() => deleteBook(book.bookID)}>Delete</button>
                        </div>
                        <Popup open={isPopupOpen} onClose={() => setPopupOpen(false)} overlayStyle={{ background: 'rgba(0, 0, 0, 0.6)' }}>
            <UpdateBook id={bkid}/>
              </Popup>
                      </div>
                    ))}
                  </div>
                :<div>No Books</div>}
            </div>
            
        </div>
    );

}
export default AdminBooks;