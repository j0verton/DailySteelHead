import react, { useEffect } from "react"
import { Card, CardHeader } from "reactstrap"
export const ActivityFeed = ({ activity }) => {

    return (
        <div>
            <Card>
                <CardHeader>{activity}</CardHeader>
            </Card>


        </div>




    )

}