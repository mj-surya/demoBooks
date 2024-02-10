import { useState } from "react";
import './AddBook.css';
import axios from "axios";

function AddBook(){
    const [title,setTitle]=useState("");
    const [author,setAuthor]=useState("");
    const [date,setDate]=useState("");
    const [id,setid]=useState("");
    const [genre,setGenre]=useState("Comics");
    const [price,setPrice]=useState(0);
    var image=null;

    const addBook=(event)=>{
        event.preventDefault();
        const jsonData = {title: title,
            userId: localStorage.getItem("id"),
            author: author,
            genre: genre,
            price: price,
            publishDate: date
        };
        const formdata = new FormData();
        formdata.append('json',JSON.stringify( jsonData));
        formdata.append('image',image);

        axios.post("http://localhost:5103/api/book/AddBook",formdata,
        {
            headers:{
                Authorization: `Bearer ${localStorage.getItem("token")}`,
                'Content-Type':'multipart/form-data',
            }
        })
        .then(async (userData)=>{
            alert("Book Added")
        })
        .catch((err)=>{
            alert(err.response.data);
        })

    }
    const handleimg=(e)=>{
        image=e.target.files[0];
        console.log(e.target.files[0]);
    }

    return(
        <div class="addbook">
            <div class="center">
                <h1>Add Book</h1>
                <form onSubmit={addBook}>
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
                            <select class="form-select searchbox" type="text" onChange={(e)=>{setGenre(e.target.value)}} aria-label="Default select example">
                            <option value="Comics" selected>Comics</option>
                            <option value="Fiction">Fiction</option>
                            <option value="Science">Science</option>
                        </select>
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
                            <div class="inputbox">
                                <input type="file" accept="image/*" required value={image} onChange={handleimg}/>
                                <span>Image</span>
                            </div>
                        </div>
                    </div>
                    <div class="row ctr">
                        <button type="submit" class="btn btn-primary" >Add Book</button>
                    </div>
                </form>
            </div>
        </div>
    );

}
export default AddBook;