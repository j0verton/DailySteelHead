import React, { useContext, useState } from "react";
import { Input } from "reactstrap";

const KeySelect = ({ setKey }) => {

    const handleSelect = e => {
        console.log(e.target.value)
        setKey(e.target.value)
    }


    const keys = ["A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G"]
    return (
        <Input type="select"
            name="keySelect"
            id="keySelect"
            onChange={handleSelect}>
            {keys.map(key => (
                <option value={key} key={key}>{key}</option>
            ))}
        </Input>

    )
};
export default KeySelect;