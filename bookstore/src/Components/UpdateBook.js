import { useEffect, useState } from "react";
import './AddBook.css';
import axios from "axios";
import { toast } from "react-toastify";

function UpdateBook({id}){
    const [title,setTitle]=useState("");
    const [author,setAuthor]=useState("");
    const [date,setDate]=useState("");
    const [genre,setGenre]=useState("");
    const [price,setPrice]=useState(0);
    const [book,setBook]=useState({});

    useEffect(() => {
        axios.get('http://localhost:5103/api/Book/GetById', {
                params: {
                    id: id
                }
            })
            .then((response) => {
                const posts = response.data;
                setBook(posts);
            })
            .catch(function(error) {
                alert(error.response.data);
            })
    }, []);
    
    useEffect(() => {
        if (book.bookID) {
            setAuthor(book.author);
            setPrice(book.price);
            setTitle(book.title);
            setDate(book.publishDate);
            setGenre(book.genre);
        }
    }, [book]);
    


    const updateBook=(event)=>{
        event.preventDefault();
        const jsonData = {title: title,
            bookID: book.bookID,
            userId:localStorage.getItem("id"),
            author: author,
            genre: genre,
            price: price,
            publishDate: date,
            image: book.image
        };
        axios.put("http://localhost:5103/api/Book/UpdateBook",jsonData,{
            params :{
                id : id
            },headers:{
                Authorization: `Bearer ${localStorage.getItem("token")}`
            }
        })
        .then(async (userData)=>{
            toast.success("Book Updated");
        })
        .catch((err)=>{
            toast.error(err.response.data);
            console.log(err);
        })

    }

    return(
        <div>
            <div class="center">
                <h1>Update Book</h1>
                <form onSubmit={updateBook}>
                    <div class="row">
                        <div class="col">
                            <div class="inputbox">
                                <input type="text" required value={title} onChange={(e)=>(setTitle(e.target.value))}/>
                                <span>Title</span>
                            </div>
                            <div class="inputbox">
                                <input type="text" required value={author} onChange={(e)=>(setAuthor(e.target.value))}/>
                                <span>Author</span>
                            </div>
                            <div class="inputbox">
                                <input type="text" required value={genre} onChange={(e)=>(setGenre(e.target.value))}/>
                                <span>Genre</span>
                            </div>
                        </div>
                        <div class="col">
                            <div class="inputbox">
                                <input type="date" required value={date} onChange={(e)=>(setDate(e.target.value))}/>
                                <span>Publish Date</span>
                            </div>
                            <div class="inputbox">
                                <input type="number" required value={price} onChange={(e)=>(setPrice(e.target.value))}/>
                                <span>Price</span>
                            </div>
                        </div>
                    </div>
                    <div class="row ctr">
                        <button type="submit" class="btn btn-primary" >Update Book</button>
                    </div>
                </form>
            </div>
        </div>
    );

}
export default UpdateBook;