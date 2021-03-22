import { Button, FormControl, FormHelperText, Grid, InputLabel, MenuItem, Select, TextField, withStyles } from "@material-ui/core"
import React, {useState, useEffect} from "react"
import useForm from "./useForm"
import { connect } from "react-redux"
import * as actions from "../actions/ToDo"
import {useToast, useToasts} from "react-toast-notifications"
 

const styles = theme =>({
    root:{

        '& .MuiTextField-root':{
            margin: theme.spacing(1),
            minWidth: 200,
        }
    },
    FormControl:{
        margin: theme.spacing(1),
        minWidth: 200,
    },
    smMargin:{
        margin: theme.spacing(1)
    }
})

const initiialFieldValues ={
    atividade_Titulo : '',
    Atividade_Dia_Hora : '',
    Atividade_DiaSemana : ''

}

const ToDoForm = ({classes,...props}) => {

    const {addToast} = useToasts()

    const validate = (fieldValues= values) =>{
        let temp={...errors}
        if('atividade_Titulo' in fieldValues)
            temp.atividade_Titulo = fieldValues.atividade_Titulo?"":"Campo Obrigatório"
        if('Atividade_DiaSemana' in fieldValues)
            temp.Atividade_DiaSemana = fieldValues.Atividade_DiaSemana?"":"Campo Obrigatório"
        if('Atividade_Dia_Hora' in fieldValues)
            temp.Atividade_Dia_Hora = fieldValues.Atividade_Dia_Hora?"":"Campo Obrigatório"
        setErrors({
            ...temp
        })
        if(fieldValues == values)
            return Object.values(temp).every(x=> x=="")
    }

    const{
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    }= useForm(initiialFieldValues, validate, props.setCurrentId)

    const inputLabel = React.useRef(null);
    const[labelWidht, setLabelWidth] = React.useState(0);
    React.useEffect(()=>{
        setLabelWidth(inputLabel.current.offsetWidth);
    }, [])

    const handleSubmit = e =>{
        e.preventDefault()
        if(validate()){
            const onSuccess = () => {
                    resetForm()
                    addToast("Submitted successfully", {appearance:"success"})    
                }
                if(props.currentId==0)
                props.createToDo(values, onSuccess)
                else
                props.updateToDo(props.currentId.values, onSuccess)
        }
    }

    useEffect(()=>{
        if(props.currentId!=0){

            setValues({
                ...props.ToDoList.find(x=> x.id==props.currentId)
            })
            setErrors({})
        }
    },[props.currentId])

    return (
        <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
            <Grid container>
                <Grid item xs={6}>
                    <TextField name="atividade_Titulo" 
                               variant="outlined" 
                               label="Titulo da Atividade" 
                               value={values.atividade_Titulo}
                               onChange={handleInputChange}
                               {...(errors.atividade_Titulo && {error:true, helperText: errors.atividade_Titulo})}
                    />
                    <TextField name="Atividade_Dia_Hora" 
                               variant="outlined" 
                               label="Dia e Hora da Atividade" 
                               value={values.Atividade_Dia_Hora}
                               onChange={handleInputChange}
                               {...(errors.Atividade_Dia_Hora && {error:true, helperText: errors.Atividade_Dia_Hora})}
                    />
                    <FormControl variant="outlined" className={classes.FormControl}
                                 {...(errors.Atividade_DiaSemana && {error:true})}
                    >
                        <InputLabel ref={inputLabel}>Dia da Semana</InputLabel>
                        <Select name="Atividade_DiaSemana"
                                value={values.Atividade_DiaSemana}
                                onChange={handleInputChange}
                                labelWidth={labelWidht}        
                                >
                                <MenuItem value=" ">Dia Semana</MenuItem>  
                                <MenuItem value="Segunda">Segunda</MenuItem>  
                                <MenuItem value="Terça">Terça</MenuItem>  
                                <MenuItem value="Quarta">Quarta</MenuItem>  
                                <MenuItem value="Quinta">Quinta</MenuItem>  
                                <MenuItem value="Sexta">Sexta</MenuItem>  
                                <MenuItem value="Sabado">Sabado</MenuItem>  
                                <MenuItem value="Domingo">Domingo</MenuItem>  
                                </Select>
                                {errors.Atividade_DiaSemana && <FormHelperText>{errors.Atividade_DiaSemana}</FormHelperText>}
                    </FormControl>
                    <div>
                        <Button
                            variant="contained"
                            color="primary"
                            type="submit"
                            className={classes.smMargin}
                        >Enviar</Button>
                                                <Button
                            variant="contained"
                            className={classes.smMargin}    
                            onClick= {resetForm}                       
                        >Apagar</Button>
                    </div>
                </Grid>
            </Grid>
        </form>  
    );
}

const mapStateToProps = state => ({
    ToDoList: state.ToDo.list
})

const mapActionToProps = {
    createToDo: actions.create,
    updateToDo:  actions.update
}


export default connect(mapStateToProps,mapActionToProps)(withStyles(styles)(ToDoForm));