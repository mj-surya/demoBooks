import { useEffect, useState } from "react";
import './Books.css';
import axios from "axios";

function Books(){
    const [books,setBooks]=useState([]);
    const [search,setSearch]=useState("All");
    const [genre, setgenre]=useState("All");

    useEffect(()=>{
        getBooks();
    },[search,genre]);

    const getBooks=()=>{
        axios.get('http://localhost:5103/api/Book',{
            params: {
              search : search,
              genre: genre
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

    var checkBooks = books.length>0?true:false;
    return(
        <div class="books">
            <div class="search row">
                <form class="form-inline d-flex justify-content-center md-form form-sm mt-0">
                    <div class="col">
                        <input class=" form-control form-control-sm ml-3 w-75" type="text" placeholder="Search by title/author" onChange={(e)=>{setSearch(e.target.value)}} aria-label="Search"/>
                    </div>
                    <div class="col">
                        <select class="form-select searchbox" onChange={(e)=>{setgenre(e.target.value)}} aria-label="Default select example">
                            <option selected>All</option>
                            <option value="Comics">Comics</option>
                            <option value="Fiction">Fiction</option>
                            <option value="Science">Science</option>
                        </select>
                    </div>
                </form>
            </div>
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
                          <a href="#" className="btn btn-primary">
                            view
                          </a>
                        </div>
                      </div>
                    ))}
                  </div>
                  
                  
                :<div>No Books, Enter a search term</div>}

            </div>
        </div>
    );

}
export default Books;