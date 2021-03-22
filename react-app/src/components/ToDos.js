import React,{useState, useEffect} from "react";
import { connect } from "react-redux";
import * as actions from "../actions/ToDo";
import ToDoForm from "./ToDoForm";
import {Button, ButtonGroup, Checkbox, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, withStyles} from "@material-ui/core"
import EditIcon from "@material-ui/icons/Edit"
import DeleteIcon from "@material-ui/icons/Delete"
import { AddPhotoAlternateSharp } from "@material-ui/icons";
import {useToast, useToasts} from "react-toast-notifications"

const styles = theme =>({
    root: {
        "& .MuiTableCell-head":{
            fontSize:"1.1rem"
        }
    },
    paper : {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }

})

const ToDos = ({classes,...props}) => {
    const [currentId, setCurrentId] = useState(0)

    useEffect(()=>{
        props.fetchAllToDos()
    },[])

    const{addToast} = useToasts()

    const onDelete= id => {
        if(window.confirm("Tem certeza que deseja deletar a atividade?"))
        props.deleteToDo(id, ()=> addToast("Deletado com sucesso", {appearance:'info'}))
    }

    return(
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={5}>
                    <ToDoForm {...({currentId, setCurrentId})}/>
                </Grid>
                <Grid item xs={7}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Id</TableCell>
                                    <TableCell>Titulo</TableCell>
                                    <TableCell>Dia e Hora</TableCell>
                                    <TableCell>Dia da semana</TableCell>
                                    <TableCell>Feito</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.ToDoList.map((record,index)=>{
                                        return(<TableRow key={index} hover>
                                            <TableCell>{record.atividade_Id}</TableCell>
                                            <TableCell>{record.atividade_Titulo}</TableCell>
                                            <TableCell>{record.atividade_Dia_Hora}</TableCell>
                                            <TableCell>{record.atividade_DiaSemana}</TableCell>
                                            <TableCell><Checkbox>{(record.feito)}</Checkbox></TableCell>
                                            <TableCell>
                                                <ButtonGroup>
                                                    <Button><EditIcon color="primary"
                                                    onClick={()=> {setCurrentId(record.atividade_Id)}}/></Button>
                                                    <Button><DeleteIcon color="secondary"
                                                    onClick={()=> onDelete(record.atividade_Id)}/></Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>)
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    );
}

const mapStateToProps = state => ({
    ToDoList: state.ToDo.list
})

const mapActionToProps = {
    fetchAllToDos: actions.fetchAll,
    deleteToDo: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(ToDos));